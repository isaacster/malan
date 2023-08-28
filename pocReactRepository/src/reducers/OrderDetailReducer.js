const initialState = {
  orderDetailData: null,
  loading: false,
  error: null,
};

const OrderDetailReducer = (state = initialState, action) => {
  switch (action.type) {
    case 'FETCH_ORDER_DETAIL_LOADING':
      return { ...state, loading: true, error: null };
    case 'FETCH_ORDER_DETAIL_SUCCESS':
      //debugger;
      return { ...state, orderDetailData: action.payload, loading: false, error: null };
    case 'FETCH_ORDER_DETAIL_FAILURE':
      return { ...state, error: action.payload, loading: false };

    case 'CREATE_ORDER_DETAIL':
      debugger;
      const updatedOrderDetailData = [...state.orderDetailData, action.payload];
      return { ...state, orderDetailData: updatedOrderDetailData };
    default:
      return state;
  }
};

export default OrderDetailReducer;