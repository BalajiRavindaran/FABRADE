import React from 'react';
import './App.css';
import { store } from "./actions/store";
import { Provider } from "react-redux";
import FabradeTransactions from "./components/fabradeTransactions";
import { Container } from "@mui/material";
import { ToastProvider } from "react-toast-notifications";


function App() {
  return (
    <Provider store={store}>
      <div className='App-header'>
        <u className="dotted"><h1>FABRADE</h1></u>
        <h3>A WEB API - REACT APPLICATION FOR CLOTHES SWAP</h3>
        <ToastProvider autoDismiss={true}>
          <Container maxWidth="lg">
            <FabradeTransactions />
          </Container>
        </ToastProvider>
      </div>
    </Provider>
  );
}

export default App;
