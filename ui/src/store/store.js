import { combineReducers, configureStore } from '@reduxjs/toolkit';
import { layoutSliceReducer } from './features/layout';
import { categorySidebarPaneReducer } from './features/sidebarCategorySlice';

const reducer = combineReducers({
  layout: layoutSliceReducer,
  categorySidebarPane: categorySidebarPaneReducer,
});

export const store = configureStore({
  reducer: reducer,
  devTools: true,
});
