import React, { useState, useEffect } from 'react';
import { fetchData , fetchOrderDetails} from '../../actions/projectActions';
import { PostOrder } from '../../actions/projectActions';
import { connect, useDispatch , useSelector} from 'react-redux';
import OrderDetail from '../../Components/ProjectManagement/CategoryProducts'
 
const CategoryContainer = ({ data,orderDetails, loading, error, fetchData , fetchOrderDetails }) => {

   
  const dispatch = useDispatch();
  const [productName, setProductName] = useState('');
  const [getOrderDetailsTriggered, setGetOrderDetailsTriggered] = useState(false);

  const AddOrderDetail = async () => {
    debugger;

    // whatever you want to send
    const orderItem = {
      CategoryId: selectedOption.id,
      //Quantity: 5,
      ProductName: productName,
    };

    dispatch(PostOrder(orderItem));
  }

  const [selectedOption, setSelectedOption] = useState("");

  const handleDropdownChange = (event) => {
    const selectedId = parseInt(event.target.value);
    const selected = data.find(option => option.id === selectedId);
    setSelectedOption(selected);
  };

  useEffect(() => {
    fetchData();
  }, [fetchData]);



  useEffect(() => {
    // When data changes (fetchData success), dispatch getOrderDetails with data
    if (data && !getOrderDetailsTriggered) { // Add a check to avoid redundant calls
    
      
      fetchOrderDetails(); // Assuming getOrderDetails needs data as an argument
 
      setGetOrderDetailsTriggered(true);
    }
  }, [ data, fetchOrderDetails]); 
 
  if (!data || data.length === 0) {
    return <p>No categories found.</p>;
  }

  if (loading) {
    return <div>Loading...</div>;
  }

  return (

    <div className="container">
      <div className="main-content">
        <div>
          <h2>Select a Category:</h2>
          <select onChange={handleDropdownChange}>
            <option value={null}>Select an option</option>
            {data.map(option => (
              <option key={option.id} value={option.id}>
                {option.description}
              </option>
            ))}
          </select>
          <div>
            {selectedOption && (
              <p>You selected: {selectedOption.description}</p>
            )}
          </div>
        </div>

        <div>
          <label htmlFor="productName">Product Name: </label>
          <input
            type="text"
            id="productName"
            value={productName}
            onChange={(e) => setProductName(e.target.value)}
          />
        </div>
      </div>

      <button className="add-order-btn" onClick={AddOrderDetail}>Add Order Detail</button>

      <br></br><br></br><br></br>
     
 <OrderDetail></OrderDetail>


    </div>


  );
};

const mapStateToProps = (state) => ({
  data: state.data.data,
  orderDetails: state.orderDetailsDataRoot.orderDetailData,
  loading: state.data.loading,
  error: state.data.error,
});

const mapDispatchToProps = {
  fetchData, fetchOrderDetails
};

export default connect(mapStateToProps, mapDispatchToProps)(CategoryContainer);  
