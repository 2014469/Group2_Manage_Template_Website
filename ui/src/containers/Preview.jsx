import SidebarSlugLocal from 'constants/SidebarSlugLocal';
import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import {
  changePreviewMode,
  selectCategorySidebarPaneState,
} from 'store/features/sidebarCategorySlice';

import PropTypes from 'prop-types';

Preview.propTypes = {
  html: PropTypes.node.isRequired,
};

function Preview(props) {
  const { html } = props;

  const dispatch = useDispatch();

  // evt handle
  function handleChangePreviewMode(mode) {
    dispatch(changePreviewMode(mode));
  }
  const { previewMode } = useSelector(selectCategorySidebarPaneState);
  return (
    <>
      <div className='page-content-wrapper overflow-hidden d-flex justify-content-center'>
        <div className={`preview-window shadow-lg preview-mode-${previewMode}`}>
          <div className='preview-toolbar d-flex align-items-center justify-content-between'>
            <div className='d-flex align-items-center'>
              <span className='material-icons preview-toolbar-dot'>
                stop_circle
              </span>
              <span className='material-icons preview-toolbar-dot'>
                stop_circle
              </span>
              <span className='material-icons preview-toolbar-dot'>
                stop_circle
              </span>
            </div>
            <div className='d-flex'>
              <button
                onClick={() =>
                  handleChangePreviewMode(SidebarSlugLocal.inspector)
                }
                className={`btn btn-sm btn-preview-toolbar d-flex align-items-center ${
                  previewMode === SidebarSlugLocal.inspector ? 'active' : ''
                }`}
              >
                <span className='material-icons'>devices</span>
              </button>
              <button
                onClick={() => handleChangePreviewMode(SidebarSlugLocal.search)}
                className={`btn btn-sm btn-preview-toolbar d-flex align-items-center ${
                  previewMode === SidebarSlugLocal.search ? 'active' : ''
                }`}
              >
                <span className='material-icons'>tv</span>
              </button>
              <button
                onClick={() => handleChangePreviewMode(SidebarSlugLocal.header)}
                className={`btn btn-sm btn-preview-toolbar d-flex align-items-center ${
                  previewMode === SidebarSlugLocal.header ? 'active' : ''
                }`}
              >
                <span className='material-icons'>tablet</span>
              </button>
              <button
                onClick={() =>
                  handleChangePreviewMode(SidebarSlugLocal.gallery)
                }
                className={`btn btn-sm btn-preview-toolbar d-flex align-items-center ${
                  previewMode === SidebarSlugLocal.gallery ? 'active' : ''
                }`}
              >
                <span className='material-icons'>smartphone</span>
              </button>
            </div>
          </div>
          <iframe
            title={'visual-iframe'}
            className={`visual-iframe`}
            srcDoc={html}
          />
        </div>
      </div>
    </>
  );
}
export default Preview;
