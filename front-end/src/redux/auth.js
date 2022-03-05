import { createSlice } from "@reduxjs/toolkit";
import { apiCallBegan } from "./api";

const initialState = {
  currentUser: null,
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
      auth.currentUser = action.payload;
      auth.loading = false;
      auth.error = null;
    },
    loginRequestedFailed: (auth, action) => {
      auth.loading = false;
      auth.error = action.payload;
    },
  },
});

export const { loginRquest, loginReceived, loginRequestedFailed } =
  authSlice.actions;

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

// export const getSearchValue = data => dispatch => {
//   return dispatch(
//     apiCallBegan({
//       url: "/Search",
//       method: "POST",
//       data,
//       onStart: searchRquest.type,
//       onSuccess: searchReceived.type,
//       onError: searchRequestedFailed.type,
//     })
//   );
// };
