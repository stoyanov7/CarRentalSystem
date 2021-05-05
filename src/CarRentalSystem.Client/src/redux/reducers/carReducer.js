const initialState = {
   carAds: {}
}

// eslint-disable-next-line import/no-anonymous-default-export
export default function(state = initialState, action) {
   switch (action.type) {
      case 'SET_SEARCH_CARADS':
         return {
            ...state,
            carAds: action.payload
         }
      default:
         return state;
   }
}