import axios from 'axios';
import {
   SET_AUTHENTICATED, 
   SET_UNAUTHENTICATED, 
   SET_ERRORS 
} from '../types';

export const loginUser = (userData, history) => (dispatch) => {
   axios
      .post('http://localhost:5001/Identity/Login', userData)
      .then(function (res) {
         setAuthenticationHeader(res);

         axios
            .get('http://localhost:5003/Dealers/GetDealerId')
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

   axios.post('http://localhost:5001/Identity/Register', { email, password })
      .then((res) => {   
         setAuthenticationHeader(res);
         
         axios.post('http://localhost:5003/Dealers/Create', { name, phoneNumber })
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