import axios from 'axios';

import { LOADING_UI, STOP_LOADING_UI } from '../types';
import { environment } from '../../environments/environment';

export const search = () => (dispatch) => {
   dispatch({ type: LOADING_UI });

   axios
      .get(`${environment.dealersApiUrl}/CarAds/Search`)
      .then((res) => {
         dispatch({
            type: 'SET_SEARCH_CARADS',
            payload: res.data.carAds
         });

         dispatch({ type: STOP_LOADING_UI });
      });
}