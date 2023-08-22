var ValidationFields = function () {

    function empty() {
        var fields = {
        }
        return fields;
    }

    function testFields() {
        var fields = {
            'Name': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
        }
        return fields;
    }
    function CategoryFields() {
        var fields = {
            'Name': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },

            'CategoryGrupId': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Grup Seçiniz'
                    }
                }
            },
        }
        return fields;
    }
    function CategoryGroupFields() {
        var fields = {
            'Name': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
            'Sira': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Grubun Sırasını Belirtin'
                    }
                }
            },
        }
        return fields;
    }
    function CourseFields() {
        var fields = {
            'Name': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
            'Description': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Açıklama Giriniz'
                    }
                }
            },
            'Price': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Ücret Giriniz'
                    }
                }
            },
            'CurrencyId': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Para Birimi Seçiniz'
                    }
                }
            },
            'Source': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Video Kaynağı Giriniz'
                    }
                }
            },
            'CategoryId': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Kategori Seçiniz'
                    }
                }
            },
        }
        return fields;
    }
    function LessonFields() {
        var fields = {
            'Name': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
            'Description': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Açıklama Giriniz'
                    }
                }
            },
            'Price': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Ücret Giriniz'
                    }
                }
            },
            'CurrencyId': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Para Birimi Seçiniz'
                    }
                }
            },
            'Source': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Video Kaynağı Giriniz'
                    }
                }
            },
            'LecturerId': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Eğitmen Seçiniz'
                    }
                }
            },
            'Duration': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Süre Giriniz'
                    }
                }
            },
            'CourseId': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Kurs Seçiniz'
                    }
                }
            },
        }
        return fields;
    }
    function CustomerFields() {
        var fields = {
            'NameSurname': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
            'Email': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Email Giriniz'
                    }
                }
            },
        }
        return fields;
    }
    function LecturerFields() {
        var fields = {
            'Name': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
        }
        return fields;
    }
    function ProfessionFields() {
        var fields = {
            'Name': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
        }
        return fields;
    }
    function SkillGroupFields() {
        var fields = {
            'Name': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
        }
        return fields;
    }
    function SkillFields() {
        var fields = {
            'Name': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
            'SkillGroupId': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
        }
        return fields;
    }
    function TrailerFields() {
        var fields = {
            'Name': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
            'Description': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Açıklama giriniz'
                    }
                }
            },
            'CourseId': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Kurs Seçiniz'
                    }
                }
            },
            'Source': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Video Kaynağı giriniz'
                    }
                }
            },
        }
        return fields;
    }
    function personelFields() {
        var fields = {
            'Adi': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen ad giriniz'
                    }
                }
            },
            'Kod': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen kod giriniz'
                    }
                }
            },
            'Eposta': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Eposta giriniz'
                    }
                }
            },
            'Telefon': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Telefon giriniz'
                    }
                }
            },
            'Parola': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Parola giriniz'
                    }
                }
            },
            'Unvan': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Unvan giriniz'
                    }
                }
            },
        }
        return fields;
    }
    function RelationFields() {
        var fields = {
            'CourseId': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Eksik Yerleri Doldurunuz'
                    }
                }
            },
        }
        return fields;
    }
    function Advisor_Package_PracticeLesson() {
        var fields = {
            'Name': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Eksik Yerleri Doldurunuz'
                    }
                }
            },
            'Description': {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Eksik Yerleri Doldurunuz'
                    }
                }
            }
        }
        return fields;
    }

    return {
        // public functions
        Empty: function () {
            return empty();
        },
        Test: function () {
            return testFields();
        },
        Personel: function () {
            return personelFields();
        },
        Category: function () {
            return CategoryFields();
        },
        CategoryGroup: function () {
            return CategoryGroupFields();
        },
        Lesson: function () {
            return LessonFields();
        },
        Course: function () {
            return CourseFields();
        },
        Customer: function () {
            return CustomerFields();
        },
        Lecturer: function () {
            return LecturerFields();
        },
        Profession: function () {
            return ProfessionFields();
        },
        Skill: function () {
            return SkillFields();
        },
        SkillGroup: function () {
            return SkillGroupFields();
        },
        Trailer: function () {
            return TrailerFields();
        }, 
         Relation: function () {
             return RelationFields();
        },
        Advisor_Package_PracticeLesson: function () {
            return Advisor_Package_PracticeLesson();
        },
    };
}();

