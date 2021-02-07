import axios from "../plugins/axios/index";

const orderUrl = "api/order/";

export const orderService = {
  getAll,
  get,
  post,
  remove
};
function getAll() {
  return axios
    .get(orderUrl)
    .then(response => {
      response.data;
      return response.data;
    })
    .catch(error => {
      console.log(error);
    });
}

function get(id) {
  return axios
    .get(orderUrl + id)
    .then(response => {
      response.data;
      return response.data;
    })
    .catch(error => {
      console.log(error);
    });
}

function post(order) {
  return axios
    .post(orderUrl, order)
    .then(() => {
      localStorage.removeItem("basket");
    })
    .catch(error => {
      console.log(error);
    });
}

function remove(id) {
  return axios.delete(orderUrl, id).catch(error => {
    console.log(error);
  });
}
