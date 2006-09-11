IIS Virtual Directory pointing to PMT should be at http://localhost/projmgtnet

When using MySql, all default dates must not be 0000-00-00 00:00:00.  It will throw an exception.  
I've set them to 0001-01-01 00:00:00, which is the value of DateTime.MinValue.