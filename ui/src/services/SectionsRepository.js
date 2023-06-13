import { get_api } from './method';

const SectionsRepository = {
  getBySlugCategory(slugCate) {
    return get_api(`/sections`, {
      CategorySlug: slugCate,
    });
  },
};

export default SectionsRepository;
