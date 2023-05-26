import React from 'react';
import PropTypes from 'prop-types';
import SideBarIndex from 'constants/SideBarIndex';
import { useSelector } from 'react-redux';

Output.propTypes = {
  html: PropTypes.string,
};

function Output(props) {
  const { html } = props;

  // global state
  const { activeTab } = useSelector((state) => state.config);

  if (activeTab !== SideBarIndex.output) return null;

  return (
    <div>
      <div className='d-flex justify-content-between align-items-center'>
        <h5>Export</h5>
      </div>
      <hr />
      <div>
        <label>Output HTML</label>
        <textarea
          readOnly
          className='form-control'
          rows={10}
          value={html}
        ></textarea>
      </div>
    </div>
  );
}

export default Output;

// rsfp
