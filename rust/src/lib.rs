#[no_mangle] pub extern "C" fn new_err() -> *mut Result<(), ()> {
    Box::into_raw(Box::new(Err(())))
}

#[no_mangle] pub unsafe extern "C" fn result_free(res: *mut Result<(), ()>) {
    let _ = Box::from_raw(res);
}

#[no_mangle] pub unsafe extern "C" fn result_is_ok(res: *const Result<(), ()>) -> bool {
    (&*res).is_ok()
}

#[no_mangle] pub unsafe extern "C" fn result_unwrap(res: *mut Result<(), ()>) -> *mut () {
    Box::into_raw(Box::new(Box::from_raw(res).unwrap()))
}

#[no_mangle] pub unsafe extern "C" fn unit_free(unit: *mut ()) {
    Box::from_raw(unit);
}
