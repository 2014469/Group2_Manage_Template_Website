import React from 'react';
import PropTypes from 'prop-types';

DefaultLayout.propTypes = {};

function DefaultLayout({ children }) {
  return (
    <div>
      <div>{children}</div>
    </div>
  );
}

export default DefaultLayout;
