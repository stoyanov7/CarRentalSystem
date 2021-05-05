import { 
   SET_ERRORS, 
   LOADING_UI, 
   STOP_LOADING_UI 
} from '../types';

const initialState = {
   errors: null,
   loading: false,
};

// eslint-disable-next-line import/no-anonymous-default-export
export default function(state = initialState, action) {
   switch(action.type) {
      case SET_ERRORS:
         return {
            ...state, 
            errors: action.payload
         };
      case LOADING_UI:
         return {
            ...state,
            loading: true
         };
      case STOP_LOADING_UI:
         return {
            ...state,
            loading: false
         };
      default: return state;
   }
}