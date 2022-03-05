import { configureStore } from "@reduxjs/toolkit";
import { persistStore } from "redux-persist";

import reducer from "./reducer";

import api from "./middleware/api";

export const store = configureStore({
  reducer,
  middleware: getDefaultMiddleware =>
    getDefaultMiddleware({
      serializableCheck: {
        // Ignore these action types
        ignoredActions: ["persist/PERSIST"],
        // Ignore these field paths in all actions
        ignoredActionPaths: ["meta.arg", "payload.timestamp"],
        // Ignore these paths in the state
        ignoredPaths: ["items.dates"],
      },
    }).concat(api),
});

export const persistor = persistStore(store);
