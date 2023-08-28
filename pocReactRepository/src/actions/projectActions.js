import myDjsonSampleata from './data.json';
import axios from 'axios';

// Action creator to fetch data from the API
export const fetchData = () => {
  return async (dispatch) => {
    try {
      // Dispatch a loading action to indicate that data is being fetched
      dispatch({ type: 'FETCH_DATA_LOADING' });

      // Fetch data from the API
      const response = await axios.get('https://localhost:44320/CategoryGate');

      // Dispatch a success action with the received data
      dispatch({ type: 'FETCH_DATA_SUCCESS', payload: response.data });
    } catch (error) {
      // Dispatch a failure action if the API call fails
      dispatch({ type: 'FETCH_DATA_FAILURE', payload: error.message });
    }
  };
};

export function PostOrder(orderItem, callback) {
  try {
    return async dispatch => { //return function
      const data = await axios.post('https://localhost:44320/OrderDetailGate/AddOrderItems', orderItem, {
        'Content-Type': 'application/json',
      });
    debugger;
      dispatch({ type: 'CREATE_ORDER_DETAIL', payload: orderItem });
    }
  } catch (error) {
    // Handle error and dispatch failure action if needed
    // For example:
    // dispatch({
    //   type: 'ADD_ORDER_ITEMS_FAILURE',
    //   payload: error.message
    // });

    throw error; // Rethrow the error for the caller to handle
  }
}

export const fetchOrderDetails = () => {
  return async (dispatch) => {
    try {
      // Dispatch a loading action to indicate that data is being fetched
      dispatch({ type: 'FETCH_ORDER_DETAIL_LOADING' });

      // Fetch data from the API
      const response = await axios.get('https://localhost:44320/OrderDetailGate');

      // Dispatch a success action with the received data
      dispatch({ type: 'FETCH_ORDER_DETAIL_SUCCESS', payload: response.data });
    } catch (error) {
      // Dispatch a failure action if the API call fails
      dispatch({ type: 'FETCH_ORDER_DETAIL_FAILURE', payload: error.message });
    }
  };
};

