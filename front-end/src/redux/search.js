import { createSlice } from "@reduxjs/toolkit";
import { apiCallBegan } from "./api";

const initialState = {
  list: [],
  loading: false,
};
const searchSlice = createSlice({
  name: "search",
  initialState,
  reducers: {
    // action => actionHandler
    searchListRquest: search => {
      search.loading = true;
    },
    searchListReceived: (search, action) => {
      search.list = action.payload;
      search.loading = false;
    },
    searchListRequestedFailed: search => {
      search.loading = false;
    },
    searchRquest: search => {
      search.loading = true;
    },
    searchReceived: (search, action) => {
      search.list = action.payload;
      search.loading = false;
    },
    searchRequestedFailed: (search, action) => {
      search.loading = false;
      search.error = action.payload;
    },
  },
});

export const {
  searchListRquest,
  searchListReceived,
  searchListRequestedFailed,
  searchRquest,
  searchReceived,
  searchRequestedFailed,
} = searchSlice.actions;

export default searchSlice.reducer;

// Action creator
const url = "/Realstate/all";
export const loadSearchList = () => dispatch => {
  return dispatch(
    apiCallBegan({
      url,
      onStart: searchListRquest.type,
      onSuccess: searchListReceived.type,
      onError: searchListRequestedFailed.type,
    })
  );
};

export const getSearchValue = data => dispatch => {
  return dispatch(
    apiCallBegan({
      url: "/Search",
      method: "POST",
      data,
      onStart: searchRquest.type,
      onSuccess: searchReceived.type,
      onError: searchRequestedFailed.type,
    })
  );
};
