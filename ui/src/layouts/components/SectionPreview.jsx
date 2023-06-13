import React from 'react';
import PropTypes from 'prop-types';

SectionPreview.propTypes = {
  blockId: PropTypes.string,
  image: PropTypes.string,
  name: PropTypes.string,
  onPushBlock: PropTypes.func,
};

function SectionPreview(props) {
  const { image, name, onPushBlock, blockId } = props;

  return (
    <div className='card card-body p-2 shadow-lg block-entry mb-2'>
      <img
        src={image}
        alt={name}
        className='img-fluid'
      />
      <div
        className='prompt'
        onClick={() => onPushBlock(blockId)}
      >
        <div className='prompt-inside'>
          <div>{name}</div>
          <button className='btn btn-outline-light btn-sm m-2'>
            Add block
          </button>
        </div>
      </div>
    </div>
  );
}

export default SectionPreview;
