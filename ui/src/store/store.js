import { combineReducers, configureStore } from '@reduxjs/toolkit';
import { sectionLayoutEditingSliceReducer } from './features/sectionLayoutSlice';
import { categorySidebarPaneReducer } from './features/sidebarCategorySlice';

const reducer = combineReducers({
  sectionLayoutEditing: sectionLayoutEditingSliceReducer,
  categorySidebarPane: categorySidebarPaneReducer,
});

export const store = configureStore({
  reducer: reducer,
  devTools: true,
});
