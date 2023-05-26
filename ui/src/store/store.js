import { combineReducers, configureStore } from '@reduxjs/toolkit';
import { layoutSliceReducer } from './features/layout';
import { configSliceReducer } from './features/config';

const reducer = combineReducers({
  layout: layoutSliceReducer,
  config: configSliceReducer,
});

export const store = configureStore({
  reducer: reducer,
  devTools: true,
});
