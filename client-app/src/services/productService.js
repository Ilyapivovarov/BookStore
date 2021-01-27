import axios from "../plugins/axios";

export const productService = {
  getAll,
  get,
  post,
  put,
  remove
};

function getAll() {
  return axios
    .get("api/product/")
    .then(response => {
      if (response.status === 200) {
        return response.data;
      }
    })
    .catch(error => {
      console.log(error);
    });
}

function get(id) {
  return axios
    .get("api/product/" + id)
    .then(response => {
      if (response.status === 200) {
        return response.data;
      }
    })
    .catch(error => {
      console.log(error);
    });
}

function post(product) {
  return axios
    .post("api/product/", product)
    .then(response => {
      if (response.status === 200) {
        return true;
      }
    })
    .catch(error => {
      console.log(error);
    });
}

function put(product) {
  return axios
    .put("api/product/", product)
    .then(response => {
      if (response.status === 200) {
        return true;
      }
    })
    .catch(error => {
      console.log(error);
    });
}

function remove(id) {
  return axios
    .put("api/product/" + id)
    .then(response => {
      if (response.status === 200) {
        return true;
      }
    })
    .catch(error => {
      console.log(error);
    });
}
