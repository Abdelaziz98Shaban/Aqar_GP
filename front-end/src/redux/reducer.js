import { combineReducers } from "redux";
import { persistReducer } from "redux-persist";
import storage from "redux-persist/lib/storage"; // defaults to localStorage for web

import entities from "./entities";
import auth from "./auth";
import ui from "./ui";

const persistConfig = {
  key: "root",
  storage,
  whitelist: ["auth"],
};

const rootReducer = combineReducers({
  entities,
  auth,
  ui,
});

export default persistReducer(persistConfig, rootReducer);
