import axios from 'axios';

import { LOADING_UI, STOP_LOADING_UI } from '../types';
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
            type: 'SET_SEARCH_CARADS',
            payload: res.data.carAds
         });

         dispatch({ type: STOP_LOADING_UI });
      })
      .catch((err) => console.log(err));
}