var fetchWrapper = async (url, init) => {
    const response = await fetch(url, init)
    let json
    try {
        json = await response.json()
    } catch (error) { }
    const ret = { status: response.status, data: json, ...json }
    return response.ok ? ret : Promise.reject(ret)
}