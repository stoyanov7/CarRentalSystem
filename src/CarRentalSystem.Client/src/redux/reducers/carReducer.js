import { SET_SEARCH_CARADS, GET_CATEGORIES, CREATE_CARAD } from '../types';

const initialState = {
   carAds: {},
   categories: []
}

// eslint-disable-next-line import/no-anonymous-default-export
export default function(state = initialState, action) {
   switch (action.type) {
      case SET_SEARCH_CARADS:
         return {
            ...state,
            carAds: action.payload
         }
      case GET_CATEGORIES:
         return {
            ...state,
            categories: action.payload
         }
      case CREATE_CARAD: 
         return {
            ...state,
            carAds: [action.payload, ...state.carAds]
         }
      default:
         return state;
   }
}