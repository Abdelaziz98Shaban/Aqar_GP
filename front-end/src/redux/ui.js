import { createSlice } from "@reduxjs/toolkit";

const initialState = { isFavCartOpened: false };

const slice = createSlice({
  name: "ui",
  initialState,
  reducers: {
    toggleFavCart: ui => {
      ui.isFavCartOpened = !ui.isFavCartOpened;
    },
  },
});

export const { toggleFavCart } = slice.actions;

export default slice.reducer;
