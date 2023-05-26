import PreviewMode from 'constants/PreivewMode';
import PropTypes from 'prop-types';
import { useDispatch, useSelector } from 'react-redux';
import { changePreviewMode } from 'store/features/config';

Preview.propTypes = {
  html: PropTypes.node.isRequired,
};

function Preview(props) {
  const { html } = props;

  const dispatch = useDispatch();

  const { previewMode } = useSelector((state) => state.config);

  function handleChangePreviewMode(mode) {
    dispatch(changePreviewMode(mode));
  }

  return (
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
              onClick={() => handleChangePreviewMode(PreviewMode.devices)}
              className={`btn btn-sm btn-preview-toolbar d-flex align-items-center ${
                previewMode === PreviewMode.devices ? 'active' : ''
              }`}
            >
              <span className='material-icons'>devices</span>
            </button>
            <button
              onClick={() => handleChangePreviewMode(PreviewMode.tv)}
              className={`btn btn-sm btn-preview-toolbar d-flex align-items-center ${
                previewMode === PreviewMode.tv ? 'active' : ''
              }`}
            >
              <span className='material-icons'>tv</span>
            </button>
            <button
              onClick={() => handleChangePreviewMode(PreviewMode.tablet)}
              className={`btn btn-sm btn-preview-toolbar d-flex align-items-center ${
                previewMode === PreviewMode.tablet ? 'active' : ''
              }`}
            >
              <span className='material-icons'>tablet</span>
            </button>
            <button
              onClick={() => handleChangePreviewMode(PreviewMode.smartphone)}
              className={`btn btn-sm btn-preview-toolbar d-flex align-items-center ${
                previewMode === PreviewMode.smartphone ? 'active' : ''
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
        ></iframe>
      </div>
    </div>
  );
}

export default Preview;
