import { createSlice } from "@reduxjs/toolkit";
import { apiCallBegan } from "./api";
import moment from "moment";

const initialState = {
  list: [],
  loading: false,
  lastFetch: null,
  search: false,
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
      search.lastFetch = Date.now();
    },
    searchListRequestedFailed: search => {
      search.loading = false;
    },
    searchRquest: search => {
      search.loading = true;
      search.search = true;
    },
    searchReceived: (search, action) => {
      search.list = action.payload;
      search.loading = false;
      search.lastFetch = Date.now();
      search.search = false;
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
export const loadSearchList = () => (dispatch, getState) => {
  const { lastFetch } = getState().entities.properties;

  const diffInMinutes = moment().diff(moment(lastFetch), "minutes");
  if (diffInMinutes < 10) return;

  return dispatch(
    apiCallBegan({
      url,
      onStart: searchListRquest.type,
      onSuccess: searchListReceived.type,
      onError: searchListRequestedFailed.type,
    })
  );
};

export const getSearchValue = data => (dispatch, getState) => {
  const { lastFetch } = getState().entities.properties;

  const diffInMinutes = moment().diff(moment(lastFetch), "minutes");
  if (diffInMinutes < 10) return;

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
