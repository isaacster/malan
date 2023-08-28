// src/reducers/index.js
import { combineReducers } from 'redux';
import projectReducer from './projectReducer';
import OrderDetailReducer from './OrderDetailReducer';

// Import your individual reducers here and combine them using combineReducers
const rootReducer = combineReducers({
     
    data: projectReducer,
   
    orderDetailsDataRoot: OrderDetailReducer,
});

export default rootReducer;
