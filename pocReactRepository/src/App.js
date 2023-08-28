import './App.css';
import { AuthContext } from './Components/AuthContext';
import React, { useContext, useState } from 'react';
import CategoryContainer from './Components/ProjectManagement/CategoryContainer';

function App() {

  const { isLoggedIn } = useContext(AuthContext);

  return (
    <div>

      <p style={{ color: "red", padding: "15px" }}>
        Hi from Itzik ! This is my app using  ReactVersion '18.2.0'
      </p>                
        <React.Fragment >
          <CategoryContainer> </CategoryContainer>                 
        </React.Fragment>        
    </div>
  );
}

export default App;
