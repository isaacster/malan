import React from 'react';
import { connect } from 'react-redux';

const OrderDetail = ({ data, orderDetailData, loading, error }) => {
  if (loading) {
    return <p>Loading...</p>;
  }

  if (error) {
    return <p>Error: {error}</p>;
  }

  // Create a mapping of category IDs to category names
  const categoryMap = {};
  if (data) {
    data.forEach(category => {
      categoryMap[category.id] = {
        name: category.description,
        totalOrders: 0,
        products: new Set(),
      };
    });

  }

  if (orderDetailData) {
    // Update the mapping with order details
    orderDetailData.forEach(orderDetail => {
      const categoryId = orderDetail.categoryId;
      if (categoryMap[categoryId]) {
        categoryMap[categoryId].totalOrders++;
        categoryMap[categoryId].products.add(orderDetail.productName);
      }
    });
  }

  return (
    <div>
      <div>
        {data ? (
          data.map(category => (
            <div key={category.id}>
              <h2>{category.description}</h2>
              <p>Total Orders: {categoryMap[category.id]?.totalOrders || 0}</p>
              <p>Distinct Products:</p>
              <ul>
                {[...(categoryMap[category.id]?.products || [])].map((productName, index) => (
                  <li key={index}>{productName}</li>
                ))}
              </ul>
            </div>
          ))
        ) : (
          <p>No data available</p>
        )}
      </div>

    </div>
  );
};

const mapStateToProps = state => ({
  data: state.data.data,
  orderDetailData: state.orderDetailsDataRoot.orderDetailData,
  loading: state.loading,
  error: state.error,
});

export default connect(mapStateToProps)(OrderDetail);
