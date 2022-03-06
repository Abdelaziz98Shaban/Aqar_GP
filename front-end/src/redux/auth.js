import { createSlice } from "@reduxjs/toolkit";
import { apiCallBegan } from "./api";

const initialState = {
  id: null,
  isAuthenticated: false,
  username: "",
  email: "",
  roles: [],
  token: "",
  expiresOn: "",
  refreshTokenExpiration: "",
  loading: false,
  error: null,
};
const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    // action => actionHandler
    loginRquest: auth => {
      auth.loading = true;
      auth.error = null;
    },
    loginReceived: (auth, action) => {
      auth.id = action.payload.id;
      auth.isAuthenticated = action.payload.isAuthenticated;
      auth.username = action.payload.username;
      auth.email = action.payload.email;
      auth.roles = action.payload.roles;
      auth.token = action.payload.token;
      auth.expiresOn = action.payload.expiresOn;
      auth.refreshTokenExpiration = action.payload.refreshTokenExpiration;
      auth.loading = false;
      auth.error = null;
    },
    loginRequestedFailed: (auth, action) => {
      auth.loading = false;
      auth.error = action.payload;
    },
    registerRquest: auth => {
      auth.loading = true;
      auth.error = null;
    },
    registerReceived: (auth, action) => {
      auth.id = action.payload.id;
      auth.isAuthenticated = action.payload.isAuthenticated;
      auth.username = action.payload.username;
      auth.email = action.payload.email;
      auth.roles = action.payload.roles;
      auth.token = action.payload.token;
      auth.expiresOn = action.payload.expiresOn;
      auth.refreshTokenExpiration = action.payload.refreshTokenExpiration;
      auth.loading = false;
      auth.error = null;
    },
    registerRequestedFailed: (auth, action) => {
      auth.loading = false;
      auth.error = action.payload;
    },
    logoutRequest: auth => {
      auth.id = "";
      auth.isAuthenticated = false;
      auth.username = "";
      auth.email = "";
      auth.roles = [];
      auth.token = "";
      auth.expiresOn = "";
      auth.refreshTokenExpiration = "";
      auth.loading = false;
      auth.error = null;
    },
    logoutRequestFailed: (auth, action) => {
      auth.loading = false;
      auth.error = action.payload;
    },
  },
});

export const {
  loginRquest,
  loginReceived,
  loginRequestedFailed,
  logoutRequest,
  logoutRequestFailed,
  registerRquest,
  registerReceived,
  registerRequestedFailed,
} = authSlice.actions;

export default authSlice.reducer;

// Action creator
const loginURL = "/Auth/login";
export const login = data => dispatch => {
  return dispatch(
    apiCallBegan({
      url: loginURL,
      method: "POST",
      data,
      onStart: loginRquest.type,
      onSuccess: loginReceived.type,
      onError: loginRequestedFailed.type,
    })
  );
};

const registerURL = "/Auth/register";
export const register = data => dispatch => {
  return dispatch(
    apiCallBegan({
      url: registerURL,
      method: "POST",
      data,
      onStart: loginRquest.type,
      onSuccess: loginReceived.type,
      onError: loginRequestedFailed.type,
    })
  );
};

export const logout = data => dispatch => {
  return dispatch(
    apiCallBegan({
      url: "/Auth/logout",
      method: "POST",
      data,
      onSuccess: logoutRequest.type,
      onError: logoutRequestFailed.type,
    })
  );
};
