import SideBarIndex from 'constants/SideBarIndex';
import { DebounceInput } from 'react-debounce-input';
import { useDispatch, useSelector } from 'react-redux';
import { changeBlockData, deleteBlock } from 'store/features/layout';
import staticBlocks from 'views/blocks';

Inspector.propTypes = {};

function Inspector(props) {
  const dispatch = useDispatch();

  // global states
  const { activeTab } = useSelector((state) => state.config);

  const { selectedBlockUuid, blocks } = useSelector((state) => state.layout);

  function handleChangeBlockData(blockUuid, key, value) {
    dispatch(changeBlockData({ blockUuid, key, value }));
  }
  function handleDeleteBlock(blockUuid) {
    dispatch(deleteBlock({ blockUuid }));
  }

  if (activeTab !== SideBarIndex.inspector) return null;

  const block = blocks.find((el) => {
    return el.uuid === selectedBlockUuid;
  });

  if (!block) {
    return (
      <div className='text-center'>First add and select block section</div>
    );
  }
  const config = staticBlocks[block.blockId].config;

  return (
    <div>
      <div className='d-flex justify-content-between align-items-center'>
        <h5>Inspector</h5>
        <button
          className='btn btn-outline-danger btn-sm'
          onClick={() => handleDeleteBlock(selectedBlockUuid)}
        >
          Delete block
        </button>
      </div>
      <hr />
      {Object.keys(config).map((el, index) => {
        if (config[el].type === 'string') {
          return (
            <div
              className='form-group'
              key={index}
            >
              <label>{config[el].name}</label>
              <DebounceInput
                debounceTimeout={500}
                type='text'
                className='form-control'
                placeholder={config[el].name}
                value={block.data[el]}
                onChange={(e) =>
                  handleChangeBlockData(selectedBlockUuid, el, e.target.value)
                }
              />
            </div>
          );
        } else if (config[el].type === 'color') {
          return (
            <div
              className='form-group'
              key={index}
            >
              <label>{config[el].name}</label>
              <DebounceInput
                debounceTimeout={500}
                type='color'
                className='form-control'
                placeholder={config[el].name}
                value={block.data[el]}
                onChange={(e) =>
                  handleChangeBlockData(selectedBlockUuid, el, e.target.value)
                }
              />
            </div>
          );
        } else if (config[el].type === 'boolean') {
          return (
            <div
              className='form-check'
              key={index}
            >
              <label>
                <input
                  type={'checkbox'}
                  className='form-check-input'
                  checked={block.data[el]}
                  onChange={(e) =>
                    handleChangeBlockData(
                      selectedBlockUuid,
                      el,
                      e.target.checked,
                    )
                  }
                />
                {config[el].name}
              </label>
            </div>
          );
        } else {
          return null;
        }
      })}
    </div>
  );
}

export default Inspector;
