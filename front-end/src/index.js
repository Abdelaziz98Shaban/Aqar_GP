import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";

import { ChakraProvider } from "@chakra-ui/react";
import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";

import store from "./redux/configureStore";

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <ChakraProvider>
        <App />
      </ChakraProvider>
    </BrowserRouter>
  </Provider>,
  document.getElementById("root")
);
