const initialState = {
   authenticated: false
};

// eslint-disable-next-line import/no-anonymous-default-export
export default function(state = initialState, action) {
   switch (action.type) {
      case 'SET_AUTHENTICATED':
         return {
               ...state,
               authenticated: true,  
         }
      case 'SET_UNAUTHENTICATED':
         return initialState
      default:
         return state;
   }
}