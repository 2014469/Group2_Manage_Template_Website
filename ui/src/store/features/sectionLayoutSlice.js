import { createSlice } from '@reduxjs/toolkit';
import { v4 as uuidv4 } from 'uuid';
import staticBlocks from 'views/blocks';

const initialState = {
  blocks: [],
  selectedBlockUuid: '',
  documentId: 'document1',
};

const sectionLayoutEditingSlice = createSlice({
  name: 'sectionLayoutEditing',
  initialState,
  reducers: {
    pushBlock: (state, action) => {
      const { blockId, data } = action.payload;
      return {
        ...state,
        blocks: [
          ...state.blocks,
          {
            uuid: uuidv4(),
            blockId: blockId,
            data: {
              ...data,
            },
          },
        ],
      };
    },
    setSelectedBlock: (state, action) => {
      return { ...state, selectedBlockUuid: action.payload.blockUuid };
    },

    reorderLayout: (state, action) => {
      return {
        ...state,
        blocks: [...action.payload.newBlocksLayout],
      };
    },

    changeBlockData: (state, action) => {
      const { blockUuid, key, value } = action.payload;
      const index = state.blocks.findIndex((el) => {
        return el.uuid === blockUuid;
      });

      const newBlocks = [...state.blocks];

      newBlocks[index].data[key] = value;
    },

    deleteBlock: (state, action) => {
      const { blockUuid } = action.payload;

      const newArr = state.blocks.filter((block) => {
        return block.uuid !== blockUuid;
      });

      return {
        ...state,
        blocks: [...newArr],
        selectedBlockUuid: '',
      };
    },
    changeDocumentId: (state, action) => {
      return {
        ...state,
        documentId: action.payload,
      };
    },
  },
});

export const {
  pushBlock,
  changeDocumentId,
  deleteBlock,
  changeBlockData,
  reorderLayout,
  setSelectedBlock,
} = sectionLayoutEditingSlice.actions;

export const selectSectionLayoutEditingState = (state) =>
  state.sectionLayoutEditing;

export const sectionLayoutEditingSliceReducer =
  sectionLayoutEditingSlice.reducer;
