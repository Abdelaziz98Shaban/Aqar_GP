import { combineReducers } from "redux";
import properties from "./properties";
import search from "./search";

export default combineReducers({
  properties,
  search,
});
