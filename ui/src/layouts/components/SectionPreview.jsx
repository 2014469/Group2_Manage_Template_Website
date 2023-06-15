import React from 'react';
import PropTypes from 'prop-types';
import { useDispatch } from 'react-redux';
import { pushBlock } from 'store/features/sectionLayoutSlice';
import SectionsRepository from 'services/SectionsRepository';
import section from 'views/section';

SectionPreview.propTypes = {
  blockId: PropTypes.string.isRequired,
  image: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  sectionSlug: PropTypes.string.isRequired,
};

function SectionPreview(props) {
  const { image, name, blockId, sectionSlug } = props;

  const dispatch = useDispatch();

  function handlePushBlock({ blockId, sectionSlug }) {
    console.log('push block');

    SectionsRepository.getDetailSectionBySlug(sectionSlug).then((res) => {
      console.log(res);
      const { hbs, exampledDatas } = res;

      const defaultData = {};
      const config = {};
      exampledDatas.forEach((exData) => {
        const { name, data, type, title } = exData;
        defaultData[name] = data;

        config[name] = { type, name: title };
      });

      const blockData = {
        hbs,
        defaultData,
        config,
      };

      dispatch(
        pushBlock({
          blockId,
          data: blockData,
        }),
      );
    });
  }

  return (
    <div className='card card-body p-2 shadow-lg block-entry mb-2'>
      <img
        src={image}
        alt={name}
        className='img-fluid'
      />
      <div
        className='prompt'
        onClick={() => handlePushBlock({ blockId, sectionSlug })}
      >
        <div className='prompt-inside'>
          <div>{name}</div>
          <button className='btn btn-outline-light btn-sm m-2'>
            Add section
          </button>
        </div>
      </div>
    </div>
  );
}

export default SectionPreview;
