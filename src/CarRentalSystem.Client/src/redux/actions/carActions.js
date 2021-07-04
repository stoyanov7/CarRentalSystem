import axios from 'axios';

import { 
   LOADING_UI, 
   STOP_LOADING_UI, 
   SET_SEARCH_CARADS,
   CREATE_CARAD, 
   GET_CATEGORIES,
   SET_ERRORS,
   CLEAR_ERRORS 
} from '../types';
import { environment } from '../../environments/environment';

export const search = (searchData) => (dispatch) => {
   dispatch({ type: LOADING_UI });

   axios
      .get(`${environment.dealersApiUrl}/CarAds/Search`, {
         params: {
            ...searchData
         }
      })
      .then((res) => {
         dispatch({
            type: SET_SEARCH_CARADS,
            payload: res.data.carAds
         });

         dispatch({ type: STOP_LOADING_UI });
      })
      .catch((err) => console.log(err));
}

export const getCaterories = () => (dispatch) => {
   axios
      .get(`${environment.dealersApiUrl}/CarAds/Categories`)
      .then((res) => {
         dispatch({
            type: GET_CATEGORIES,
            payload: res.data
         })
      })
      .catch((err) => console.log(err));
}

export const createNewCar = (createCarData) => (dispatch) => {
   axios
      .post(`${environment.dealersApiUrl}/CarAds/Create`, createCarData)
      .then((res) => {
         dispatch({
            type: CREATE_CARAD,
            payload: res.data
         });

         dispatch(clearErrors());
      })
      .catch((err) => {
         dispatch({
            type: SET_ERRORS,
            payload: err.response.data.errors
         });
      })
}

export const clearErrors = () => (dispatch) => {
   dispatch({ type: CLEAR_ERRORS });
};