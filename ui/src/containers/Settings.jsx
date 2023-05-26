import React from 'react';
import PropTypes from 'prop-types';
import { useDispatch, useSelector } from 'react-redux';
import SideBarIndex from 'constants/SideBarIndex';
import { changeDocumentId } from 'store/features/layout';
import staticDocuments from 'views/documents';

Settings.propTypes = {};

function Settings(props) {
  const dispatch = useDispatch();

  // global state
  const { activeTab } = useSelector((state) => state.config);
  const { documentId } = useSelector((state) => state.layout);

  if (activeTab !== SideBarIndex.setting) return null;

  function handleDocumentChange(documentId) {
    dispatch(changeDocumentId(documentId));
  }

  return (
    <div>
      <div className='d-flex justify-content-between align-items-center'>
        <h5>Settings</h5>
      </div>
      <hr />
      <div>
        <label>Document template</label>
        <select
          className='form-control'
          onChange={(e) => handleDocumentChange(e.target.value)}
          value={documentId}
        >
          {Object.keys(staticDocuments).map((documentId) => (
            <option
              key={documentId}
              value={documentId}
            >
              {staticDocuments[documentId].name}
            </option>
          ))}
        </select>
      </div>
    </div>
  );
}

export default Settings;
