import { get_api } from './method';

export async function getAllCategories() {
  return get_api('/categories');
}
