import React, { useState } from 'react';
import PropTypes from 'prop-types';
import staticBlocks from 'views/blocks';
import BlockPreview from 'layouts/components/BlockPreview';
import { useSelector } from 'react-redux';
import SideBarIndex from 'constants/SideBarIndex';

Search.propTypes = {
  onPushBlock: PropTypes.func.isRequired,
};

function Search(props) {
  const { onPushBlock } = props;
  const { activeTab } = useSelector((state) => state.config);

  const [searchValue, setSearchValue] = useState('');

  function handleChangeSearchValue(newValue) {
    setSearchValue(newValue);
  }

  if (activeTab !== SideBarIndex.search) return null;

  return (
    <div>
      <input
        type='text'
        className='form-control mb-3 form-control-lg shadow'
        placeholder='Search block component...'
        value={searchValue}
        onChange={(e) => handleChangeSearchValue(e.target.value)}
      />
      <hr />
      <div>
        {Object.keys(staticBlocks).map((blockId, index) => {
          const block = staticBlocks[blockId];
          if (
            searchValue !== '' &&
            index < 10 &&
            block.name.toLowerCase().indexOf(searchValue.toLowerCase()) > -1
          ) {
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
    </div>
  );
}

export default Search;
