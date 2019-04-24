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


    return {
        uploadCustomersData,
        getCustomersData,
    }
}

export default customerService;