import { createSlice } from "@reduxjs/toolkit";

import { apiCallBegan } from "./api";

import moment from "moment";

const initialState = { list: [], loading: false, lastFetch: null };

const slice = createSlice({
  name: "properties",
  initialState,
  reducers: {
    // actions => action handlers
    propertiesRequested: properties => {
      properties.loading = true;
    },
    propertiesReceived: (properties, action) => {
      properties.list = action.payload;
      properties.loading = false;
      properties.lastFetch = Date.now();
    },
    propertiesRequestedFailed: properties => {
      properties.loading = false;
    },
  },
});

export const {
  propertiesRequested,
  propertiesReceived,
  propertiesRequestedFailed,
} = slice.actions;
export default slice.reducer;

// Action Creators
const url = "/Realstate/all";

export const loadProperties = () => (dispatch, getState) => {
  const { lastFetch } = getState().entities.properties;

  const diffInMinutes = moment().diff(moment(lastFetch), "minutes");
  if (diffInMinutes < 10) return;
  return dispatch(
    apiCallBegan({
      url,
      onStart: propertiesRequested.type,
      onSuccess: propertiesReceived.type,
      onError: propertiesRequestedFailed.type,
    })
  );
};
