// src/store.js
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import rootReducer from './reducers'; 
import ProjectReducer from './reducers/projectReducer';
import thunkMiddleware from 'redux-thunk'; //Redux Thunk allows actions to return functions

// Creating a Redux store that holds the complete state tree
const store = createStore(rootReducer, applyMiddleware(thunkMiddleware));

export default store;
