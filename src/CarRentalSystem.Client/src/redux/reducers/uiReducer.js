import { SET_ERRORS } from '../types';

const initialState = {
   errors: null
};

// eslint-disable-next-line import/no-anonymous-default-export
export default function(state = initialState, action) {
   switch(action.type) {
      case SET_ERRORS:
         return {
            ...state, 
            errors: action.payload
         };
      default: return state;
   }
}