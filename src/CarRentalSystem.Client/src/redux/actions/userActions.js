import axios from 'axios';
import {
   SET_AUTHENTICATED, 
   SET_UNAUTHENTICATED, 
   SET_ERRORS 
} from '../types';
import { environment } from '../../environments/environment';

export const loginUser = (userData, history) => (dispatch) => {
   axios
      .post(`${environment.identityApiUrl}/Identity/Login`, userData)
      .then(function (res) {
         setAuthenticationHeader(res);

         axios
            .get(`${environment.dealersApiUrlApiUrl}/Dealers/GetDealerId`)
            .then((res) => {
               localStorage.setItem('dealerId', res.data);
               dispatch({ type: SET_AUTHENTICATED });
               history.push('/');
            });         
      })
      .catch((err) => {       
         dispatch({
            type: SET_ERRORS,
            payload: err.response.data.errors
         });
      });
}

export const signupUser = (newUserData, history) => (dispatch) => {
   const { email, password, name, phoneNumber } = newUserData;

   axios.post(`${environment.identityApiUrl}/Identity/Register`, { email, password })
      .then((res) => {   
         setAuthenticationHeader(res);
         
         axios.post(`${environment.dealersApiUrlApiUrl}/Dealers/Create`, { name, phoneNumber })
         .then((res) => {
            localStorage.setItem('dealerId', res.data);
            dispatch({ type: SET_AUTHENTICATED });

            history.push('/');
         })
      });
}

export const logoutUser = () => (dispatch) => {
   localStorage.removeItem('token');
   localStorage.removeItem('dealerId');

   delete axios.defaults.headers.common['Authorization'];

   dispatch({ type: SET_UNAUTHENTICATED });
}

const setAuthenticationHeader = (res) => {
   const token = `Bearer ${res.data.token}`;
   localStorage.setItem('token', token);
   axios.defaults.headers.common['Authorization'] = token;
}