import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  activeTab: 0,
  previewMode: 0,
};

const configSlice = createSlice({
  name: 'config',
  initialState,
  reducers: {
    changeActiveTab: (state, action) => {
      return {
        ...state,
        activeTab: action.payload,
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

export const { changeActiveTab, changePreviewMode } = configSlice.actions;

export const configSliceReducer = configSlice.reducer;
