import React from 'react';
import PropTypes from 'prop-types';
import { useSelector } from 'react-redux';
import staticBlocks from 'views/blocks';
import BlockPreview from 'layouts/components/BlockPreview';
import SideBarIndex from 'constants/SideBarIndex';

BlocksGallery.propTypes = {
  index: PropTypes.number.isRequired,
  onPushBlock: PropTypes.func.isRequired,
  category: PropTypes.string.isRequired,
};

function BlocksGallery(props) {
  const { category, onPushBlock, index } = props;

  // global states
  const { activeTab } = useSelector((state) => state.config);

  if (activeTab !== index) return null;

  return (
    <div>
      <h5>Category: {category}</h5>
      <hr />
      {Object.keys(staticBlocks).map((blockId) => {
        const block = staticBlocks[blockId];
        if (block.category === category) {
          return (
            <BlockPreview
              key={blockId}
              name={block.name}
              blockId={blockId}
              image={block.previewImageUrl}
              onPushBlock={onPushBlock}
            />
          );
        } else {
          return null;
        }
      })}
    </div>
  );
}

export default BlocksGallery;
