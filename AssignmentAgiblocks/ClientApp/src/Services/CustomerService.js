const baseAPIUrl = 'https://localhost:5001';

function customerService() {

    function uploadCustomersData(file) {
        const fd = new FormData()
        fd.append('file', file)
        fetch(`${baseAPIUrl}/api/customer/upload`, {
            method: 'POST',
            body: fd,
        })
    }

    function getCustomersData() {
        return fetch(`${baseAPIUrl}/api/customer`).then(data => data.json());
    };

    function deleteCustomerData(id) {
        return fetch(`${baseAPIUrl}/api/customer/${id}`, {
            method: 'DELETE',
        })
    }

    return {
        uploadCustomersData,
        getCustomersData,
        deleteCustomerData,
    }
}

export default customerService;