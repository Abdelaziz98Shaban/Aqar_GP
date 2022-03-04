import { createSlice } from "@reduxjs/toolkit";

import { apiCallBegan } from "./api";

import moment from "moment";

const initialState = {
  propertiesForSale: [],
  propertiesForRent: [],
  loading: false,
  lastFetch: null,
};

const slice = createSlice({
  name: "properties",
  initialState,
  reducers: {
    propertiesForSaleRequested: properties => {
      properties.loading = true;
    },
    propertiesForSaleReceived: (properties, action) => {
      properties.propertiesForSale = action.payload;
      properties.loading = false;
      properties.lastFetch = Date.now();
    },
    propertiesForSaleRequestedFailed: properties => {
      properties.loading = false;
    },
    propertiesForRentRequested: properties => {
      properties.loading = true;
    },
    propertiesForRentReceived: (properties, action) => {
      properties.propertiesForRent = action.payload;
      properties.loading = false;
      properties.lastFetch = Date.now();
    },
    propertiesForRentRequestedFailed: properties => {
      properties.loading = false;
    },
  },
});

export const {
  propertiesForSaleRequested,
  propertiesForSaleReceived,
  propertiesForSaleRequestedFailed,
  propertiesForRentRequested,
  propertiesForRentReceived,
  propertiesForRentRequestedFailed,
} = slice.actions;
export default slice.reducer;

// Action Creators
const url = "/Search";

export const loadpropertiesForSale = () => (dispatch, getState) => {
  const { lastFetch } = getState().entities.properties;

  const diffInMinutes = moment().diff(moment(lastFetch), "minutes");
  if (diffInMinutes < 10) return;
  return dispatch(
    apiCallBegan({
      url,
      method: "POST",
      data: {
        Status: "sale",
      },
      onStart: propertiesForSaleRequested.type,
      onSuccess: propertiesForSaleReceived.type,
      onError: propertiesForSaleRequestedFailed.type,
    })
  );
};
export const loadpropertiesForRent = () => (dispatch, getState) => {
  const { lastFetch } = getState().entities.properties;

  const diffInMinutes = moment().diff(moment(lastFetch), "minutes");
  if (diffInMinutes < 10) return;
  return dispatch(
    apiCallBegan({
      url,
      method: "POST",
      data: {
        Status: "rent",
      },
      onStart: propertiesForRentRequested.type,
      onSuccess: propertiesForRentReceived.type,
      onError: propertiesForRentRequestedFailed.type,
    })
  );
};
