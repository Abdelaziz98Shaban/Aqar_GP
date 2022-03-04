import { createSlice } from "@reduxjs/toolkit";
import { apiCallBegan } from "./api";
import moment from "moment";

const initialState = { list: [], loading: false, lastFetch: null };
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
      search.loading = true;
      search.lastFetch = Date.now();
    },
    searchListRequestedFailed: search => {
      search.loading = false;
    },
  },
});

export const {
  searchListRquest,
  searchListReceived,
  searchListRequestedFailed,
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
