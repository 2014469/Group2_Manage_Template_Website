import { createSlice } from '@reduxjs/toolkit';
import SidebarNameLocal from 'constants/SidebarNameLocal';
import SidebarSlugLocal from 'constants/SidebarSlugLocal';

const initialState = {
  slugActiveTab: SidebarSlugLocal.inspector,
  nameActiveTab: SidebarNameLocal.inspector,
};

const categorySidebarPaneSlice = createSlice({
  name: 'categorySidebarSlice',
  initialState,
  reducers: {
    changeSlugActiveTab: (state, action) => {
      return {
        ...state,
        slugActiveTab: action.payload,
      };
    },
    changeNameActiveTab: (state, action) => {
      return {
        ...state,
        nameActiveTab: action.payload,
      };
    },

    changePreviewMode: (state, action) => {
      return {
        ...state,
        previewMode: action.payload,
      };
    },
  },
});

export const { changeSlugActiveTab, changePreviewMode, changeNameActiveTab } =
  categorySidebarPaneSlice.actions;

export const selectCategorySidebarPaneState = (state) =>
  state.categorySidebarPane;

export const categorySidebarPaneReducer = categorySidebarPaneSlice.reducer;
