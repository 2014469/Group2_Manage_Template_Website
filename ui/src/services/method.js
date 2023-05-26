import httpCommon from 'http-common';

export async function get_api(your_api, params = []) {
  try {
    const response = await httpCommon.get(your_api, { params });

    const data = response.data;

    if (data.isSuccess) return data.result;
    else return null;
  } catch (error) {
    console.log('Error ', error.message);
    return null;
  }
}

export async function post_api(your_api, formData) {
  try {
    const response = await httpCommon.post(your_api, formData);

    const data = response.data;
    if (data.isSuccess) {
      return data.result;
    } else {
      return null;
    }
  } catch (error) {
    console.log('Error ', error.message);
    return null;
  }
}

export async function put_api(your_api, formData) {
  try {
    let formDataObject = Object.fromEntries(formData.entries());
    // Format the plain form data as JSON
    let formDataJsonString = JSON.stringify(formDataObject);

    const response = await httpCommon({
      method: 'put',
      url: your_api,
      data: formDataJsonString,
      headers: {
        accept: 'application/json',
        'Content-Type': 'application/json',
      },
    });

    const data = response.data;
    if (data.isSuccess) {
      return data.result;
    } else {
      return null;
    }
  } catch (error) {
    console.log('Error ', error.message);
    return null;
  }
}

export async function delete_api(your_api) {
  try {
    const response = await httpCommon.delete(your_api);

    const data = response.data;
    if (data.isSuccess) {
      return data.result;
    } else {
      return null;
    }
  } catch (error) {
    console.log('Error ', error.message);
    return null;
  }
}
