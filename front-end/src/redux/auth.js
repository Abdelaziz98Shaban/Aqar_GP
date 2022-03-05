import { createSlice } from "@reduxjs/toolkit";
import { apiCallBegan } from "./api";

const initialState = {
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
    logoutRequest: auth => {
      auth.isAuthenticated = null;
      auth.username = null;
      auth.email = null;
      auth.roles = null;
      auth.token = null;
      auth.expiresOn = null;
      auth.refreshTokenExpiration = null;
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
